using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace matalaGUI4
{
    enum FileTypeExtension
    {
        TXT = 1,
        DOC,
        DOCX,
        PDF,
        PPTX
    }
    internal class DataFile
    {
        private string fileName;
        DateTime lastUpadateTime = new DateTime();
        private string data;
        FileTypeExtension type;
        public static uint counter = 0;
        readonly uint fileNumber;

        private bool IsValidFileName(string fileName)
        {
            char[] invalidChars = { ')', '>', '?', '*', ':', '/', '\\', '|', '<', '!', '%', '$', '!' };
            foreach (char c in invalidChars)
            {
                if (fileName.Contains(c))
                {
                    return false;
                }
            }
            return true;
        }
        public void setFile(string fileName)
        {
            if (IsValidFileName(fileName))
                this.fileName = fileName;
            else
            {
                Console.WriteLine("Invalid name! reEnter a vaild one: ");
                string newFileName = Console.ReadLine();
                setFile(newFileName);
            }

        }
        public new FileTypeExtension GetType() { return type; }
        public string getFile() { return fileName; }

        public void setData(string Data) { this.data = Data; }
        public string getData() { return data; }

        public uint getFileNum() { return fileNumber; }
        public void SetTime() { lastUpadateTime = DateTime.Now; }
        public DateTime GetTime() { return lastUpadateTime; }

        public float GetSize()
        {
            return data.Length * sizeof(char);
        }

        public DataFile(string fileName, string data, FileTypeExtension type)
        {
            setFile(fileName);
            setData(data);
            this.type = type;
            SetTime();

            counter++;
            fileNumber = counter;
        }

        public static int counterF = 1;
        public DataFile() : this($"samefile{counterF}", string.Empty, FileTypeExtension.TXT)
        {
            data = string.Empty;
            counterF++;

        }
        public DataFile(DataFile other)
        {
            fileName = other.fileName + "_copy";
            data = other.data;
            lastUpadateTime = DateTime.Now;
            counter++;
        }

        public void dir()
        {
            Console.WriteLine("{0} {1} KB {2} {3}", lastUpadateTime, GetSize() / 1024, getFile(), type);
        }
        public string PrintFile()
        {
            string str = "";
            str += "File #" + fileNumber + ": \r\n";
            str += "File Name: " + getFile() + ": \r\n";
            str += "File Data: " + getData() + "\r\n";
            str += "Data size: " + GetSize() + "\r\n";
            str += "File Date: " + lastUpadateTime.ToString("dd-MM-yyyy") + "\r\n";
            str += "File type: " + type + "\r\n";
            return str;
        }
    }
}
