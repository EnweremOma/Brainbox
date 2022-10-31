using Brainbox.Domain.Abstract;
using Brainbox.Domain.Data;
using Brainbox.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brainbox.Domain.Concrete;

public class EFUserRepository: GenericRepository<User>, IUserRepository
{
    public EFUserRepository(BrainboxDbContext context) : base(context)
    {
        Context = context;
    }

    public BrainboxDbContext Context { get; }

    public async Task<bool> CommitAsync()
    {
        return await Context.SaveChangesAsync() > 0;
    }
}
