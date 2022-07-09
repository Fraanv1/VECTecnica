using System;

namespace VEC.Domain.Interfaces
{
	public interface ISoftDelete
	{
		bool Activo { get; set; }
	}
}