using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

namespace Autorization
{
    public class ViewModel
    {
        /// <summary>
        /// Проверяем есть ли пользователь по фамилии и паролю
        /// </summary>
        /// <returns></returns>
        public static int CheckUser(List<UserModel> users, string login, string pass)
        {
            foreach (var user in users)
            {
                if ((user.login == login) && (user.password == pass))
                {
                    return user.Id;
                }
            }
            return 0;

        }
        /// <summary>
        /// Получаем пользователя находя по фамилии и паролю
        /// </summary>
        /// <returns></returns>
        public static UserModel GetUser(List<UserModel> users, int id)
        {
            foreach (var user in users)
            {
                if (user.Id == id)
                {
                    return user;
                }
            }
            return null;

        }
        /// <summary>
        /// Получаем список пользователей с users.txt файла
        /// </summary>
        /// <returns></returns>
        public static List<UserModel> GetUsers()
        {
            string filePath = ".\\..\\..\\authorization.txt";
            string[] lines = System.IO.File.ReadAllLines(filePath, Encoding.GetEncoding(1251));

            UserModel account = new UserModel();
            List<UserModel> accounts = new List<UserModel>();
            int i = 1;


            foreach (string line in lines)
            {
                string[] temp = line.Split(',');

                account.Id = i;
                account.login = temp[0];
                account.password = temp[1];

                accounts.Add(account);
                account = new UserModel();
                i++;
            }


            return accounts;
        }
        /// <summary>
        /// Получаем список клиентов с users.txt файла
        /// </summary>
        /// <returns></returns>
        public static List<ClientModel> GetClients()
        {
            string filePath = ".\\..\\..\\clients.txt";
            string[] lines = System.IO.File.ReadAllLines(filePath, Encoding.GetEncoding(1251));

            ClientModel account = new ClientModel();
            List<ClientModel> accounts = new List<ClientModel>();


            foreach (string line in lines)
            {
                string[] temp = line.Split(',');

                account.name = temp[0];
                account.surname = temp[1];
                account.markAuto = temp[2];
                account.prodCount = Convert.ToInt32(temp[3]);
                

                accounts.Add(account);
                account = new ClientModel();
            }


            return accounts;
        }

        //
        public static List<Cars> GetCars()
        {
            string filePathCloth = ".\\..\\..\\cars.txt";
            string[] lines = System.IO.File.ReadAllLines(filePathCloth, Encoding.UTF8);
            Cars car = new Cars();
            List<Cars> cars = new List<Cars>();

            foreach (string line in lines)
            {
                string[] temp = line.Split(',');

                car.mark = temp[0];
                car.model = temp[1];
                car.date = Convert.ToInt32(temp[2]);
                car.count = Convert.ToInt32(temp[3]);

                cars.Add(car);
                car = new Cars();
            }


            return cars;
        }

        public static void WriteUser(string textToTxt)
        {
            string filePath = ".\\..\\..\\authorization.txt";

            using (StreamWriter writer = System.IO.File.AppendText(filePath))
            {
                writer.Write(writer.NewLine);
                writer.Write(textToTxt);
            }
        }
        public static void WriteClient(string textToTxt)
        {
            string filePath = ".\\..\\..\\clients.txt";

            using (StreamWriter writer = System.IO.File.AppendText(filePath))
            {
                writer.Write(writer.NewLine);
                writer.Write(textToTxt);
            }
        }

        public static void ReplaceInFile(string filePath, string searchText, string replaceText)
        {
            StreamReader reader = new StreamReader(filePath);
            string content = reader.ReadToEnd();
            reader.Close();

            content = Regex.Replace(content, searchText, replaceText);

            StreamWriter writer = new StreamWriter(filePath);
            writer.Write(content);
            writer.Close();
        }
    }
}
