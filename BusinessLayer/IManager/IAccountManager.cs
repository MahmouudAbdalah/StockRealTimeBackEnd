using ViewModelLayer.Account;

namespace BusinessLayer.IManager
{

    public interface IAccountManager
    {
        Task Register(RegisterModelVm registerModelVm);
        Task<string> Login(LoginModelVm LoginModelVm);
    }
}
