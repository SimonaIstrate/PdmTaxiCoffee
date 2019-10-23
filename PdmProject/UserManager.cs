using System;
namespace PdmProject
{
    public class UserManager
    {
        private User user;

        private UserManager(User user)
        {
            this.user = user;
        }

        public User getUser()
        {
            return this.user;
        }

        private static UserManager instance;

        public static void init(User user)
        {
            if (user != null)
            {
                instance = new UserManager(user);
            }
        }

        public static UserManager Instance
        {
            get
            {
                return instance;
            }
        }
    }
}
