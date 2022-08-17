namespace GameCheckerAPI.Models
{
    public class Account
    {
        public int id { get; set; }
        public UserModel AccountHolder { get; set; }

        public Account() { }
        public Account(UserModel AccountHolder)
        {
            this.AccountHolder = AccountHolder;
        }
    }
}
