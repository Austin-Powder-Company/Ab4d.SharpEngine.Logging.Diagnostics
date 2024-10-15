[![#: SharpEngine](https://raw.githubusercontent.com/Austin-Powder-Company/sharpengine-contrib/master/badge.svg)](https://www.ab4d.com/SharpEngine.aspx)

Utilities for writing SharpEngine logs to `System.Diagnostics.Trace`.

## Usage

Place the following line in your setup code somewhere. After it executes, SharpEngine logs will be written to `System.Diagnostics.Trace`.

```cs
Ab4d.SharpEngine.Logging.Diagnostics.TraceWriter.WriteTo();
```
