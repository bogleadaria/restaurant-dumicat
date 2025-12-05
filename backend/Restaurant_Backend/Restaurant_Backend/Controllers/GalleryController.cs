using Microsoft.AspNetCore.Mvc;
using Restaurant_Backend.Repository;
using Restaurant_Backend.Entities;
using Restaurant_Backend.Repository.Gallery;

namespace Restaurant_Backend.Controllers;

[ApiController]
[Route("api/gallery")]
public class GalleryController : ControllerBase
{
    private readonly IGalleryRepository _galleryRepository;
    public GalleryController(IGalleryRepository galleryRepository)
    {
        _galleryRepository = galleryRepository;
    }
    [HttpGet("{id}/image")]  ////////////// for getting the image directly
    public IActionResult GetImage(int id)
    {
        var gallery = _galleryRepository.GetById(id);
        if (gallery == null || gallery.Data == null)
        {
            return NotFound();
        }

        // Stream the binary data with the correct content type
        return File(gallery.Data, gallery.ContentType, gallery.FileName);
    }

    [HttpGet]
    public IActionResult GetGalleries()  ////////////// for getting the JSON 
    {
        return  Ok(_galleryRepository.GetAll());
    }

    [HttpGet("{id}")]
    public IActionResult GetGallery(int id)
    {
        return Ok(_galleryRepository.GetById(id));
    }

    [HttpPost]
    public IActionResult AddGallery(Gallery gallery)
    {
        var tmp_gallery = _galleryRepository.GetById(gallery.Id);
        if (tmp_gallery != null)
        {
            return BadRequest("Photo already exists");
        }

        _galleryRepository.Add(gallery);
        return Ok(gallery);
    }

    [HttpPut]
    public IActionResult UpdateGallery(Gallery gallery)
    {
        _galleryRepository.Update(gallery);
        return Ok(gallery);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteGallery(int id)
    {
        var gallery = _galleryRepository.GetById(id);
        _galleryRepository.Delete(gallery);
        return Ok();
    }
}