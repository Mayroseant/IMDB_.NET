using MovieMayDL.Models;
using System;
using System.Linq;

namespace MovieMayDL
{
    public class UserDL
    {
        public MovieMayContext _context = new MovieMayContext();
        public bool UserValidate(User user)
        {
            User login_user = _context.Users.Where(x => x.UserRole == user.UserRole && x.Email == user.Email && x.Pwd == user.Pwd).FirstOrDefault();
            if (login_user != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool UserReg(User user)
        {
            User used_email = _context.Users.Where(x => x.Email == user.Email).FirstOrDefault();
            if(used_email != null)
            {
                return false;            
            }
            else
            {
                _context.Users.Add(user);
                _context.SaveChanges();

                return true;
            }
        }
    }
}
