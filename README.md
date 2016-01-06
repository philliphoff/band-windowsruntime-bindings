#Windows Runtime Bindings for the Microsoft Band SDK

Provides Windows Runtime bindings for the Microsoft Band SDK, enabling use of the SDK from native (i.e. C++) Universal Windows 10 applications.

##Installation

Within a Windows 10 Universal C++ project, install the bindings via NuGet (e.g. using the NuGet Package Manager).

```bash
> Install-Package Microsoft.Band.WindowsRuntime
```

##Use

The bindings are contained within the `Microsoft::Band::WindowsRuntime` namespace.

Enumerate Bands paired to the device using `GetBandsAsync()` methods on the static `BandClientManager` instance.  Connect to a Band using the `ConnectAsync()` method.

```cpp
using namespace concurrency;
using namespace Microsoft::Band::WindowsRuntime;

auto bandsOperation = BandClientManager::Instance->GetBandsAsync();
auto bandsTask = create_task(bandsOperation);

bandsTask.then([this](IIterable<IBandInfo^>^ bands)
{
    auto bandsIterator = bands->First();

    if (bandsIterator->HasCurrent)
    {
        auto band = bandsIterator->Current;

        auto clientOperation = BandClientManager::Instance->ConnectAsync(band);
        auto clientTask = create_task(clientOperation);

        clientTask.then([this](IBandClient^ client) 
        {
            auto firmwareVersionOperation = client->GetFirmwareVersionAsync();
            auto firmwareVersionTask = create_task(firmwareVersionOperation);

            firmwareVersionTask.then([this](String^ firmwareVersion)
            {
                // Display the firmware version to the user.
                
                // Dispose of the client (client->Dispose()) when done.
            });
        });
    }
});

```

##License

This project is bound by the MIT license. Use of the Microsoft Band SDK is bound by its own [license](http://go.microsoft.com/fwlink/?LinkID=525149).