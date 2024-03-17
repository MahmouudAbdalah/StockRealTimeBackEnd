using RepositoriesLayer;

namespace BusinessLayer.Common
{
    public abstract class ManagerBase
    {

        private readonly IUnitOfWork unitOfWork;

        protected ManagerBase(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
    }
}
