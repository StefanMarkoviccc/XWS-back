using PostService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostService.Repository
{
    public class PostSettingsRepository : BaseRepository<PostSettings>, IPostSettingsRepository
    {
        public PostSettingsRepository(PostContext context) : base(context) { }
    }
}
