﻿
namespace DemoSOLID.Layouts.Contracts
{
    public interface ILayoutFactory
    {
        ILayout CreateLayout(string type);
    }
}
