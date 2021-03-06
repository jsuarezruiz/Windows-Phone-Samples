// ------------------------------------------------------------------------
// ========================================================================
// THIS CODE AND INFORMATION ARE GENERATED BY AUTOMATIC CODE GENERATOR
// ========================================================================
// Template:   ServiceLocator.tt
using WPAppStudio.Ioc;
using WPAppStudio.Ioc.Interfaces;
using WPAppStudio.ViewModel;
using WPAppStudio.ViewModel.Interfaces;

namespace WPAppStudio.Services
{
    /// <summary>
    /// Implementation of the ViewModel locator service based on IoC.
    /// </summary>
    [System.Runtime.CompilerServices.CompilerGenerated]
    [System.CodeDom.Compiler.GeneratedCode("Radarc", "4.0")]
    public class ViewModelLocatorService
    {
        // IoC container
        private readonly IContainer _container;

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModelLocatorService" /> class.
        /// </summary>
        public ViewModelLocatorService()
        {
            _container = new Container();
        }

        /// <summary>
        /// Gets the reference to a TheTeam_AlbumViewModel.
        /// </summary>
		public ITheTeam_AlbumViewModel TheTeam_AlbumViewModel
        {
            get { return _container.Resolve<TheTeam_AlbumViewModel>(); }
        }

        /// <summary>
        /// Gets the reference to a blog_DetailViewModel.
        /// </summary>
		public Iblog_DetailViewModel blog_DetailViewModel
        {
            get { return _container.Resolve<blog_DetailViewModel>(); }
        }

        /// <summary>
        /// Gets the reference to a videos_DetailVideosViewModel.
        /// </summary>
		public Ivideos_DetailVideosViewModel videos_DetailVideosViewModel
        {
            get { return _container.Resolve<videos_DetailVideosViewModel>(); }
        }

        /// <summary>
        /// Gets the reference to a awards_DetailViewModel.
        /// </summary>
		public Iawards_DetailViewModel awards_DetailViewModel
        {
            get { return _container.Resolve<awards_DetailViewModel>(); }
        }

        /// <summary>
        /// Gets the reference to a TheTeam_DetailViewModel.
        /// </summary>
		public ITheTeam_DetailViewModel TheTeam_DetailViewModel
        {
            get { return _container.Resolve<TheTeam_DetailViewModel>(); }
        }
    }
}
