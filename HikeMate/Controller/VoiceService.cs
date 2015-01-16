using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Media.SpeechRecognition;
using Windows.Storage;

namespace HikeMate.Controller
{
    class VoiceService
    {
        public VoiceService()
        {
            RegisterVoiceCommands();
        }

        public static async void RegisterVoiceCommands()
        {
            var VCDFile = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///VoiceCommandDefinition.xml"));
            await VoiceCommandManager.InstallCommandSetsFromStorageFileAsync(VCDFile);
        }


    }
}
