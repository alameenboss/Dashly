import { Component, OnInit } from '@angular/core';
import { FileFolder } from '../../models/FileFolder';
import { FileService } from '../../services/file.service';

@Component({
  selector: 'app-play-lists',
  templateUrl: './play-lists.component.html',
  styleUrls: ['./play-lists.component.scss']
})
export class PlayListsComponent implements OnInit {

  drives: string[];
  fileandfolder: FileFolder;
  previousFolder: string;
  constructor(private fileService: FileService) { }

  ngOnInit(): void {
    this.getDrives();
  }

  getDrives() {
    this.fileService.getDrives().subscribe(response => {
      this.drives = response;
    });
  }

  getFiles(path: string) {
    this.fileService.getFiles(path).subscribe(response => {
      this.fileandfolder = response;
      console.log(this.fileandfolder)
    });
  }
}
