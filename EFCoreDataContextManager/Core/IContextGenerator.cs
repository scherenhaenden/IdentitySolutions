using Microsoft.EntityFrameworkCore;

namespace EFCoreDataContextManager.Core;

public interface IContextGenerator
{
    T GenerateContext<T>(DataBaseTypeAvailable dataBaseTypeAvailable) where T : DbContext;
}