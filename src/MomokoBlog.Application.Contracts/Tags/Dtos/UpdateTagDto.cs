using System;

namespace MomokoBlog.Tags.Dtos;

[Serializable]
public class UpdateTagDto
{
    public string Name { get; set; }

    public string? NickName { get; set; }

    public int ArtCount { get; set; }
}