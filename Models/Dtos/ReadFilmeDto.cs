﻿using System.ComponentModel.DataAnnotations;


namespace FilmeAPI;

public class ReadFilmeDto
{
  public string Titulo { get; set; } = string.Empty;

  public string Genero { get; set; } = string.Empty;

  public int Duracao { get; set; }

  public DateTime HoraDaConsulta { get; set; } = DateTime.Now;

  public ICollection<ReadSessaoDto> Sessoes { get; set; } = new List<ReadSessaoDto>();
}
