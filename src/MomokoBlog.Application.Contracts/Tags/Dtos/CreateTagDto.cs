using System;

namespace MomokoBlog.Tags.Dtos;

[Serializable]
public class CreateTagDto
{
    public string Name { get; set; }

    public string? NickName { get; set; }

    public int ArtCount { get; set; }
}