using Microsoft.AspNetCore.Mvc;
using TelematicaBlog.DAL;

namespace TelematicaBlog.Controllers;

public class ControllerBaseConDataContext: ControllerBase
{
    protected readonly BlogContext _dc;
    public ControllerBaseConDataContext(BlogContext dc)
    {
        _dc = dc;
    }
}
