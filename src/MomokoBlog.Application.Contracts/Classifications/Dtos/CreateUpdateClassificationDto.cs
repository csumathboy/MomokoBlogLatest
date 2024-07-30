using System;

namespace MomokoBlog.Classifications.Dtos;

[Serializable]
public class CreateUpdateClassificationDto
{
    public string Name { get; set; }

    public string? Description { get; set; }

    public string? NickName { get; set; }

    public int ArtCount { get; set; }
}