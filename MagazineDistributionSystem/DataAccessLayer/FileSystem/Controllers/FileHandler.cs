using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.FileSystem.Controllers
{
    public class FileHandler : IDisposable
    {
        #region Fields

        string FilePath;
        Stream stream;
        StreamReader reader;
        StreamWriter writer;

        #endregion

        #region Constructors

        /// <summary>
        /// Used to create a new instance of the disposable class FileHandler
        /// </summary>
        /// <param name="FilePathParam">FilePath to perform operations on</param>
        public FileHandler(string FilePathParam)
        {
            this.FilePath = FilePathParam;
        }

        #endregion

        #region Properties
        
        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Reads the data from the specified location line by line
        /// </summary>
        /// <returns>Data read from the specified location</returns>
        public List<string> Read()
        {
            // If the file was found
            if (Test())
            {
                // Ensures that any errors that occur may be caught
                try
                {
                    // Instantiates the reader to be used
                    using (reader = new StreamReader(new FileStream(this.FilePath, FileMode.Open, FileAccess.Read)))
                    {
                        // Creates an empty list
                        List<string> temp = new List<string>();
                        // While not the end of file
                        while (!reader.EndOfStream)
                        {
                            // Add the read line to the temporary list
                            temp.Add(reader.ReadLine());
                        }
                        reader.Close();
                        // return the temporary list
                        return temp;
                    }
                } // If any exception was thrown let it be caught and handled here
                catch (Exception)
                { throw; }
            }
            else // Unable to find the file
            { throw new FileNotFoundException(string.Format("Unable to locate file:\n '{0}'", this.FilePath)); }
        }

        /// <summary>
        /// Will overwrite any data contained within a file before writing the new data
        /// </summary>
        /// <param name="data">Data to write to the file</param>
        /// <param name="CreateNewFile">If the file does not exist, should one be created</param>
        /// <returns>If the overwriting of data was successful</returns>
        public bool Overwrite(List<string> data, bool CreateNewFile = false)
        {
            // Ensure the file exists
            if (Test())
            {
                // instantiate the writer
                using (writer = new StreamWriter(new FileStream(this.FilePath, FileMode.Open, FileAccess.Write)))
                {
                    // Calls the write data method
                    WriteData(data, writer);
                }

                // Overwrite successful
                return true;
            }
            else
            {
                throw new FileNotFoundException();
            }
        }

        /// <summary>
        /// Appends data to the specified file
        /// </summary>
        /// <param name="data">Data to append to the file</param>
        /// <param name="CreateNewFile">If the file does not exist, should one be created</param>
        /// <returns>If the append method was successful</returns>
        public bool Append(List<string> data, bool CreateNewFile = false)
        {
            // Test if the file exists
            if (Test())
            {
                // Instantiate the writer object with Append Mode
                using (writer = new StreamWriter(new FileStream(this.FilePath, FileMode.Append, FileAccess.Write)))
                {
                    // Calls the WriteData method
                    WriteData(data, writer);
                }

                // Append was successful
                return true;
            }
            else
            {
                throw new FileNotFoundException();
            }
        }
        
        /// <summary>
        /// Create a new file from the specified file path
        /// </summary>
        /// <returns></returns>
        public bool CreateNewFile()
        {
            try
            {
                // If the file already exists
                if (Test())
                {
                    throw new Exception("File '{0}' already exists.");
                }
                else
                {
                    // creates the file
                    stream = new FileStream(this.FilePath, FileMode.CreateNew, FileAccess.Write);
                    return true;
                }
            }
            catch (FileNotFoundException)
            {
                throw;
            }
            catch (DirectoryNotFoundException)
            {
                throw;
            }
            catch (UnauthorizedAccessException)
            {
                throw;
            }
            catch (IOException)
            {
                throw;
            }
            catch (Exception)
            {
                throw new Exception(string.Format("An unexpected error has occured whilst trying to create a file:\n '{0}'", this.FilePath));
            }
        }

        /// <summary>
        /// Test if the file exists
        /// </summary>
        /// <returns>If the file was found</returns>
        public bool Test()
        {
            return File.Exists(this.FilePath);
        }
        
        /// <summary>
        /// Used to dispose of this object once complete
        /// </summary>
        public void Dispose()
        {
            try
            { stream.Close(); }
            catch (Exception) { }

            try
            { reader.Close(); }
            catch (Exception) { }

            try
            { writer.Close(); }
            catch (Exception) { }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Writes the specified data to the specified file
        /// </summary>
        /// <param name="data">Data to write to the file</param>
        /// <param name="fileMode">FileMode to use when writing to the file</param>
        /// <returns></returns>
        private bool WriteData(List<string> data, StreamWriter writerParam)
        {
            // For each piece of data
            for (int i = 0; i < data.Count; i++)
            {
                // Write data to the file
                writerParam.WriteLine(data.Count);
            }

            // Close the writer object to release the memory
            writer.Close();

            // successfully wrote data
            return true;
        }

        #endregion

#endregion
    }
}
