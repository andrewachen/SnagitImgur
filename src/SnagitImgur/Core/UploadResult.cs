using System;
using System.Xml.Serialization;

namespace SnagitImgur.Core
{
    [Serializable]
    [XmlRoot("rsp")]
    public class UploadResult
    {
        [XmlAttribute("stat")]
        public string Status { get; set; }

        [XmlElement("image_hash")]
        public string ImageHash { get; set; }

        [XmlElement("delete_hash")]
        public string DeleteHash { get; set; }

        [XmlElement("original_image")]
        public string OriginalImage { get; set; }

        [XmlElement("large_thumbnail")]
        public string LargeThumbnail { get; set; }
        
        [XmlElement("small_thumbnail")]
        public string SmallThumbnail { get; set; }

        [XmlElement("imgur_page")]
        public string ImgurPage { get; set; }

        [XmlElement("delete_page")]
        public string DeletePage { get; set; }
    }
}