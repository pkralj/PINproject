using BlazorApp1.Data;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp1.Services;

public class UserAccountService
{
    AppDBContext _context;
    public UserAccountService(AppDBContext context)
    {
        _context = context;
    }
    
    public async Task<List<UserAccount>> GetUserAccountsAsync()
    {
        var result =  _context.UserAccounts;
        return await Task.FromResult(result.ToList());
    }
    
    public async Task<UserAccount> GetUserAccountByIdAsync(int id)
    {
        return await _context.UserAccounts.Include(x=>x.myScheduleItems).FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<UserAccount> InsertUserAccountAsync(UserAccount userAccount)
    {
        _context.UserAccounts.Add(userAccount);
        await _context.SaveChangesAsync();
        return userAccount;
    }
    
    public async Task<UserAccount> UpdateUserAccountAsync(int id, UserAccount userAccount)
    {
        var item = await _context.UserAccounts.FindAsync(id);
        if (item == null) return null;
        item.Username = userAccount.Username;
        item.Password = userAccount.Password;
        item.isAdmin = userAccount.isAdmin;
        item.myScheduleItems = userAccount.myScheduleItems;
        _context.UserAccounts.Update(item);
        await _context.SaveChangesAsync();
        return item;
    }
    
    public async Task<UserAccount> DeleteUserAccountAsync(int id)
    {
        var item = await _context.UserAccounts.FindAsync(id);
        if (item == null) return null;
        _context.UserAccounts.Remove(item);
        await _context.SaveChangesAsync();
        return item;
    }
    
    private bool UserAccountExists(int id)
    {
        return _context.UserAccounts.Any(e => e.Id == id);
    }
}