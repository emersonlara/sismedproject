namespace SisMedico.Domain.Entities;

public class PagedResult<T> : IPagedList where T : class
{
    public string ReferenceAction { get; set; }
    public IEnumerable<T> Data { get; set; }
    public int PageIndex { get; set; }
    public int PageSize { get; set; }
    public string Query { get; set; }

    public string SelectedValue { get; set; }

    public int TotalResults { get; set; }
    public double TotalPages => Math.Ceiling((double)TotalResults / PageSize);

    public int MaxPageShow => 7;
    public int MaxPageShowOrTotalPage => (int)(MaxPageShow < TotalPages ? MaxPageShow : TotalPages);

    public bool HasPrevious => PageIndex > 1;
    public bool HasNext => PageIndex < TotalPages;

    public int Proximo => PageIndex + 1;
    public int Anterior => PageIndex - 1;
    public int Primeiro => 1;

    public string ClassDisabledNext => !HasNext ? "disabled" : "";
    public string ClassDisabledPrevious => !HasPrevious ? "disabled" : "";

    public bool SemProximo => !HasNext;
    public bool SemAnterior => !HasPrevious;

}

public interface IPagedList
{
    public string ReferenceAction { get; set; }
    public int PageIndex { get; set; }
    public int PageSize { get; set; }
    public string Query { get; set; }

    public string SelectedValue { get; set; }

    public int TotalResults { get; set; }

    public double TotalPages { get; }

    public int MaxPageShow { get; }
    public int MaxPageShowOrTotalPage { get; }

    public bool HasPrevious { get; }
    public bool HasNext { get; }

    public int Proximo { get; }
    public int Anterior { get; }
    public int Primeiro { get; }

    public string ClassDisabledNext { get; }
    public string ClassDisabledPrevious { get; }

    public bool SemProximo { get; }
    public bool SemAnterior { get; }

}
