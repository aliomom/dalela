using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NawafizApp.Services.Dtos
{
  public  class GalleryPhotoDto
    {
        public int Id { set; get; }
        public byte[] photo { set; get; }
        public int BranchId { set; get; }
        public string branchName { set; get; }
        List<byte> photos { set; get; }
    }
}
