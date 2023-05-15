using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Authors.API.Controllers
{

    [ApiController]
    [Route("api/authorscover")]
    public class AuthorsCoverController : ControllerBase
    {
        private readonly ICourseLibraryRepository _courseLibraryRepository;
        private readonly IMapper _mapper;

        public AuthorsCoverController(ICourseLibraryRepository courseLibraryRepository, IMapper mapper)
        {
            _courseLibraryRepository = courseLibraryRepository ?? throw new ArgumentNullException(nameof(courseLibraryRepository));
            _mapper = mapper;
        }

        [HttpGet("{id}", Name = "GetAuthorCover")]
        // cancellationTokent this token used to cancel task when user navigates from page
        public async Task<IActionResult> GetBook(int id, CancellationToken cancellationToken)
        {
            var authorEntity = await _courseLibraryRepository.GetAuthorAsync(id);
            if (authorEntity == null)
                return NotFound();

            Models.External.AuthorCoverDto? bookCover = await _courseLibraryRepository.GetAuthorCoverAsync("dummycover");

            IEnumerable<Models.External.AuthorCoverDto>? bookCovers1 = await _courseLibraryRepository.GetAuthorCoversProcessOneByOneAsync(id, cancellationToken);

            IEnumerable<Models.External.AuthorCoverDto>? bookCovers2 = await _courseLibraryRepository.GetAuthorCoversProcessAfterWaitForAllAsync(id);

            for (int i = 0; i < 100; i++)
            {
                // we have to canceled this heaby calculation also
                
                //if (cancellationToken.IsCancellationRequested)
                //    break;
                
                // or

                // cancellationToken.ThrowIfCancellationRequested();

                {
                    // some logic to perfom
                }
            }
            return Ok((authorEntity, bookCovers1));
        }

    }
}
