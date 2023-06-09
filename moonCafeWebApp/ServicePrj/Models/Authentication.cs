namespace ServicePrj.Models
{
    public class Authentication
    {
        public string LoginErrorMessage { get; set; }
        public bool loginControl(string username, string password)
        {
            using (var context = new MooncafedbContext())
            {
                if (username == null || password == null)
                {
                    LoginErrorMessage = "Kullanıcı Adı veya Şifre boş bırakılamaz";
                    return false;

                }
                else
                {
                    var user = context.CmUsers.FirstOrDefault(u => u.Username == username);
                    if (user == null)
                    {
                        LoginErrorMessage = "Kullanıcı bulunamadı";
                        return false;
                    }
                    if (username == user.Username)
                    {
                        if (password == user.Password)
                        {
                            return true;
                        }
                        else
                        {
                            LoginErrorMessage = username + " için şifre hatalı";
                        }
                    }
                    return false;
                }
            }

        }
    }
}
