namespace API.Helpers;

public class Params
{
    private string _specialty;
    private string _laboratory;
    private string _specie;
    private decimal _price;
    private decimal MinPrice = 0;
    private int _monthInit;
    private int _monthFinish;
    private string _reason;
    private int _pageSize = 5;
    private const int MaxPageSize = 50;
    private int _pageIndex = 1;
    private string _search;

    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
    }

    public int PageIndex
    {
        get => _pageIndex;
        set => _pageIndex = (value <= 0) ? 1 : value;
    }

    public string Search
    {
        get => _search;
        set => _search = (!String.IsNullOrEmpty(value)) ? value.ToLower() : "";
    }
    public string Specialty
    {
        get => _specialty;
        set => _specialty = (!String.IsNullOrEmpty(value)) ? value.ToLower() : "";
    }
    public string Laboratory
    {
        get => _laboratory;
        set => _laboratory = (!String.IsNullOrEmpty(value)) ? value.ToLower() : "";
    }
    public string Specie
    {
        get => _specie;
        set => _specie = (!String.IsNullOrEmpty(value)) ? value.ToLower() : "";
    }
    public decimal Price
    {
        get => _price;
        set => _price = (value < MinPrice) ? MinPrice : value;
    }
    public int MonthInit
    {
        get => _monthInit;
        set => _monthInit = (value < 1) ? 1 : value;
    }
    public int MonthFinish
    {
        get => _monthFinish;
        set => _monthFinish = (value < 3) ? 3 : value;
    }
    public string Reason
    {
        get => _reason;
        set => _reason = (!String.IsNullOrEmpty(value)) ? value.ToLower() : "";
    }
}