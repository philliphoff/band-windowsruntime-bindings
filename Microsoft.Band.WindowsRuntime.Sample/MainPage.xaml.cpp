//
// MainPage.xaml.cpp
// Implementation of the MainPage class.
//

#include "pch.h"
#include "MainPage.xaml.h"

using namespace Microsoft_Band_WindowsRuntime_Sample;

using namespace concurrency;
using namespace Microsoft::Band::WindowsRuntime;
using namespace Platform;
using namespace Windows::Foundation;
using namespace Windows::Foundation::Collections;
using namespace Windows::UI::Xaml;
using namespace Windows::UI::Xaml::Controls;
using namespace Windows::UI::Xaml::Controls::Primitives;
using namespace Windows::UI::Xaml::Data;
using namespace Windows::UI::Xaml::Input;
using namespace Windows::UI::Xaml::Media;
using namespace Windows::UI::Xaml::Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

MainPage::MainPage()
{
	InitializeComponent();
}


void Microsoft_Band_WindowsRuntime_Sample::MainPage::Button_Click(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e)
{
	auto bandsOperation = BandClientManager::Instance->GetBandsAsync();

	auto bandsTask = create_task(bandsOperation);

	bandsTask.then([this](IIterable<IBandInfo^>^ bands)
	{
		auto bandsIterator = bands->First();

		if (bandsIterator->HasCurrent)
		{
			auto band = bandsIterator->Current;
			auto name = band->Name;
			auto connectionType = band->ConnectionType;

			auto clientOperation = BandClientManager::Instance->ConnectAsync(band);

			auto clientTask = create_task(clientOperation);

			clientTask.then([this](IBandClient^ client) 
			{
				auto firmwareVersionOperation = client->GetFirmwareVersionAsync();

				auto firmwareVersionTask = create_task(firmwareVersionOperation);

				firmwareVersionTask.then([this](String^ firmwareVersion)
				{
				});
			});
		}
	});
}
