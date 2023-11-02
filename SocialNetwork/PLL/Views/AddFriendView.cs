using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Servises;
using SocialNetwork.PLL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PLL.Views
{
    public class AddFriendView
    {
        UserService userService;

        public AddFriendView(UserService userService)
        {
            this.userService = userService;
        }

        public void Show(User user)
        {
            try
            {
                var friendAddData = new FriendAddData();

                Console.WriteLine("Введите email пользователя для добавления в друзья");
                friendAddData.FriendEmail = Console.ReadLine();
                friendAddData.UserId = user.Id;

                this.userService.AddFriend(friendAddData);
                SuccessMessage.Show("Пользователь добавлен в друзья");
            }

            catch (UserNotFoundException)
            {
                AlertMessage.Show("Пользователь с таким email не найден");
            }

            catch (Exception)
            {
                AlertMessage.Show("Произошла ошибка при добавлении пользователя в друзья");
            }

        }
    }
}
