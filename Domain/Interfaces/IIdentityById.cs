using System.Data.Common;

namespace Domain.Interfaces;

public interface IIdentityById
{
    public int Id { get; set; }
}