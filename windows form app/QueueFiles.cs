using matalaGUI4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace matalaGUI4
{
    internal class QueueFiles
    {
        DataFile[] filePointer;
        int index;

        public QueueFiles()
        {
            filePointer = new DataFile[1];
            index = 0;
        }
        public bool IsEmpty()
        {
            return index == 0;
        }
        public int Length => index;

        public QueueFiles(QueueFiles queue)
        {
            filePointer = new DataFile[queue.filePointer.Length];
            queue.filePointer.CopyTo(filePointer, 0);
            index = queue.Length;
        }
        public void Enqueue(DataFile newFile)
        {
            /*for (int i = 0; i < filePointer.Length; i++)
            {
                if (CompareFiles.EqualFiles(filePointer[i], newFile) == true)
                {
                    MessageBox.Show("The file already exists in the queue.");
                    return;
                }
            }*/
            filePointer[index++] = newFile;
            Array.Resize(ref filePointer, filePointer.Length + 1);
            MessageBox.Show("File #" + newFile.getFileNum() + " has been added");

        
        }

        public DataFile Dequeue()
        {
            if (IsEmpty())
            {
                MessageBox.Show("Queue is empty");
                return null;
            }

            DataFile file = filePointer[0];

            for (int i = 0; i < index - 1; i++)
            {
                filePointer[i + 1] = filePointer[i];
            }
            index--;
            filePointer[index] = null;
            return file;
        }

        public DataFile BigFile()
        {
            int temp = 0;
            if (IsEmpty())
                return null;

            QueueFiles helpQueue = new QueueFiles();
            DataFile Largfile = Dequeue();
            DataFile currentFile = new DataFile();

            while (!helpQueue.IsEmpty())
            {
                helpQueue.Enqueue(currentFile);
                temp = CompareFiles.CompareSizeFiles(Largfile, currentFile);
            }
            if (temp == 1)
                return currentFile;
            if (temp == 0)
                return Largfile;
            return null;
        }

        public string PrintQueue()
        {
            if (IsEmpty())
            {
                MessageBox.Show("The queue is empty");
                return null;
            }

            DataFile file;
            string str = "";
            for (int i = 0; i < index; i++)
            {
                file = Dequeue();
                str += file.PrintFile();
                Enqueue(file);
            }
            return str;


        }

        public DataFile[] SearchFileByType(FileTypeExtension type)
        {
            DataFile[] fileTypes = new DataFile[index];
            QueueFiles helpQueue = new QueueFiles();
            DataFile file;
            while (!helpQueue.IsEmpty())
            {
                for (int i = 0; i < index; i++)
                {
                    file = filePointer[i];
                    helpQueue.Enqueue(file);
                    if (file.GetType() == type)
                    {
                        fileTypes[i] = file;
                    }
                }
                helpQueue.Dequeue();
            }
            return fileTypes;
        }


    }



}
