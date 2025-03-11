using RGB.NET.Core;
using RGB.NET.Devices.DynamicLighting;
using RGB.NET.Presets.Decorators;
using RGB.NET.Presets.Textures;
using RGB.NET.Presets.Textures.Gradients;

RGBSurface surface = new RGBSurface();
surface.Load(DynamicLightingDeviceProvider.Instance);
surface.AlignDevices();

surface.RegisterUpdateTrigger(new TimerUpdateTrigger());

ILedGroup allLeds = new ListLedGroup(surface, surface.Leds);
RainbowGradient rainbow = new RainbowGradient();
rainbow.AddDecorator(new MoveGradientDecorator(surface));
ITexture texture = new ConicalGradientTexture(new Size(10, 10), rainbow);
allLeds.Brush = new TextureBrush(texture);

Console.ReadKey();