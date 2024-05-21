using Core.DataAccess;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, RcdbContext>, IUserDal
    {
        public List<OperationClaim> GetOperationClaims(User user)
        {
            using (var context = new RcdbContext())
            {
                var result = from oc in context.OperationClaims
                              join uoc in context.UserOperationClaims
                              on oc.Id equals uoc.OperationClaimId
                              where uoc.UserId == user.UserId
                              select new OperationClaim { Id = oc.Id, Name = oc.Name };

                return result.ToList();
            }
            throw new Exception("Kullanici yok");
        }
    }
}
