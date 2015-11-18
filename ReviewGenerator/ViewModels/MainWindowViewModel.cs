using System.ComponentModel;
using System.Windows.Input;
using ReviewGenerator.Infrastructure;
using TestContextMenu;

namespace ReviewGenerator.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private int _positiveReviewsCount;
        private int _negativeReviewsCount;
        private ICommand _generateCommand;
        private string _status;
        private readonly ReviewsGenerator _reviewsGenerator;
        private readonly ReviewsSerializer _reviewsSerializer;

        public MainWindowViewModel()
        {
            _reviewsGenerator = new ReviewsGenerator();
            _reviewsSerializer = new ReviewsSerializer();
            _generateCommand = new RelayCommand(x => GenerateAndSaveReviews(), y => true);
        }

        private void GenerateAndSaveReviews()
        {
            var reviews = _reviewsGenerator.Generate(PositiveReviewsCount, NegativeReviewsCount);
            Status = _reviewsSerializer.Save(reviews);
        }

        private void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public int PositiveReviewsCount 
        {
            get { return _positiveReviewsCount; }
            set
            {
                _positiveReviewsCount = value;
                OnPropertyChanged("PositiveReviewsCount");
            }
        }

        public int NegativeReviewsCount
        {
            get { return _negativeReviewsCount; }
            set
            {
                _negativeReviewsCount = value;
                OnPropertyChanged("NegativeReviewsCount");
            }
        }

        public ICommand GenerateCommand
        {
            get { return _generateCommand; }
            set
            {
                _generateCommand = value;
                OnPropertyChanged("GenerateCommand");
            }
        }

        public string Status
        {
            get { return _status; }
            set
            {
                _status = value;
                OnPropertyChanged("Status");
            }
        }
    }
}
