using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    class Logger:IRepository
    {
        private static Logger _instance;
        private string _logPath = @"C:\Users\asood\Desktop\LogFile.txt";
        private string _savePath = @"C:\Users\asood\Desktop\SaveFile.txt";

        private Logger() { }

        public static Logger Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Logger();
                }
                return _instance;
            }
        }
        public void Log(string message)
        {
            try
            {
                using (FileStream file = new FileStream(_logPath, FileMode.Append))
                using (StreamWriter writer = new StreamWriter(file, Encoding.Unicode))
                {
                    writer.WriteLine(message);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.StackTrace);
            }
        }
        public void Save(IRepository product)
        {
            //try
            //{
            //    using (FileStream file = new FileStream(_savePath, FileMode.Create))
            //    using (StreamWriter writer = new StreamWriter(file, Encoding.Unicode))
            //    {
            //        writer.WriteLine(message);
            //    }
            //}
            //catch (Exception exception)
            //{
            //    Console.WriteLine(exception.StackTrace);
            //}
        }
    }
}
