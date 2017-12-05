using static System.Console;
using GitHubClient.Infracture.Models;

namespace GitHubClient.ConsoleAppClient
{
    public class DisplayData
    {
        private readonly UserApiResult _userApiResultFiltered;

        public DisplayData(UserApiResult userApiResultFiltered)
        {
            this._userApiResultFiltered = userApiResultFiltered;
        }


        public void DisplayOnScreen()
        {
            WriteLine();
            WriteLine("########################################################");
            WriteLine();


            PrintUserInfo();

            WriteLine();
            WriteLine("Top repositories:");
            WriteLine("---------------------------------------------------------");
            WriteLine();

            PrintRepositories();

            WriteLine();
            WriteLine("########################################################");
            WriteLine();
        }

        private void PrintUserInfo()
        {
            WriteLine($"User name : {_userApiResultFiltered.UserInfo.UserName}");
            WriteLine($"Location : {_userApiResultFiltered.UserInfo.Location}");
            WriteLine($"Avatar Url : {_userApiResultFiltered.UserInfo.AvatarUrl}");
        }

        private void PrintRepositories()
        {
            int i = 0;
            foreach (var repository in _userApiResultFiltered.Repositories)
            {
                i++;
                WriteLine($"{i} repository : {repository.Name}");
            }
        }

    }
}
