﻿namespace SGBIMFurnas.Dtos.EtapaDto;

public class EtapaReadDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime DateTime { get; set; } = DateTime.Now;
}
