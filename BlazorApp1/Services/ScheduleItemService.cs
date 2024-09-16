using BlazorApp1.Data;

namespace BlazorApp1.Services;

public class ScheduleItemService
{
    AppDBContext _context;
    public ScheduleItemService(AppDBContext context)
    {
        _context = context;
    }
    
    public async Task<List<ScheduleItem>> GetScheduleItemsAsync()
    {
        var result =  _context.ScheduleItems;
        return await Task.FromResult(result.ToList());
    }
    
    public async Task<ScheduleItem> GetScheduleItemByIdAsync(int id)
    {
       return await _context.ScheduleItems.FindAsync(id);
    }

    public async Task<ScheduleItem> InsertScheduleItemAsync(ScheduleItem scheduleItem)
    {
        _context.ScheduleItems.Add(scheduleItem);
        await _context.SaveChangesAsync();
        return scheduleItem;
    }
    
    public async Task<ScheduleItem> UpdateScheduleItemAsync(int id, ScheduleItem scheduleItem)
    {
        var item = await _context.ScheduleItems.FindAsync(id);
        if (item == null) return null;
        item.Location = scheduleItem.Location;
        item.Title = scheduleItem.Title;
        item.Host = scheduleItem.Host;
        item.Description = scheduleItem.Description;
        item.Date = scheduleItem.Date;
        item.Time = scheduleItem.Time;
        item.Vacancies = scheduleItem.Vacancies;
        _context.ScheduleItems.Update(item);
        await _context.SaveChangesAsync();
        return item;
    }
    
    public async Task<ScheduleItem> DeleteScheduleItemAsync(int id)
    {
        var item = await _context.ScheduleItems.FindAsync(id);
        if (item == null) return null;
        _context.ScheduleItems.Remove(item);
        await _context.SaveChangesAsync();
        return item;
    }
    
    private bool ScheduleItemExists(int id)
    {
        return _context.ScheduleItems.Any(e => e.Id == id);
    }
}