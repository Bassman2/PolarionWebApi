using PolarionWebApi.Service.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PolarionWebApi;

public class Attributes
{
    internal Attributes(AttributesModel model)
    {
        Id = model.Id;
        Name = model.Name;
    }

    public string Id { get; }

    public string Name { get; }
}
