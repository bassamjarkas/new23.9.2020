import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { UserService } from 'src/app/Services/User.service';
import { User } from 'src/app/_Models/User';
import { AlertifyService } from '../../Services/Alertify.service';
//import { NgxGalleryOptions, NgxGalleryImage, NgxGalleryAnimation } from '@ngx-gallery/core';
//import { NgxImageGalleryComponent, GALLERY_IMAGE, GALLERY_CONF } from "ngx-image-gallery";
 
@Component({
  selector: 'app-members-Details',
  templateUrl: './members-Details.component.html',
  styleUrls: ['./members-Details.component.css']
})
export class MembersDetailsComponent implements OnInit {
  @Input() user:User;
  // @ViewChild(NgxImageGalleryComponent) ngxImageGallery: NgxImageGalleryComponent;
  //  conf: GALLERY_CONF = {
  //   imageOffset: '0px',
  //    showDeleteControl: false,
  //    showImageTitle: false,
  //  };
   
  
  //galleryOptions: NgxGalleryOptions[];
  //galleryImages: NgxGalleryImage[];
  constructor(private userservice:UserService,private alert:AlertifyService,private route:ActivatedRoute) { }

  ngOnInit() {
    
    this.route.data.subscribe(data=>{this.user=data['user']});
   
    // this.galleryOptions=[{
      // width:'500px',height:"500px",imagePercent:100,thumbnailsColumns:4,
      // imageAnimation:NgxGalleryAnimation.Slide,preview:false
    // }];
    //this.galleryImages=this.getImages();
//----------------------------------------------------------------------------------

    }
  //   images:GALLERY_IMAGE[]=getImages(){
  // const ImagesUrl=[];
  // for(let i:number;i<this.user.photos.length;++i){
  //   ImagesUrl.push({
  //     small:this.user.photos[i].url,
  //     medium:this.user.photos[i].url,
  //     big:this.user.photos[i].url
  //   });
  }
  //return ImagesUrl;
//}

  // loaduser(){
  //   this.userservice.getuser(+this.route.snapshot.params['id']).subscribe(
  //    (user:User)=>{this.user=user},
  //    error=>{this.alert.Error(error)}
  //   );
  // }

//}
