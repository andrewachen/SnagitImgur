using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using SnagitImgur.Annotations;

namespace SnagitImgur.View
{
    public class UploadViewModel : INotifyPropertyChanged
    {
        private readonly ISnagitFacade snagitFacade;

        public UploadViewModel(ISnagitFacade snagitFacade)
        {
            this.snagitFacade = snagitFacade;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}