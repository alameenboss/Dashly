import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { GithubProcessorService } from '../../services/githubprocessor.service';

@Component({
  selector: 'app-card-view',
  templateUrl: './card-view.component.html',
  styleUrls: ['./card-view.component.scss']
})
export class CardViewComponent implements OnInit {

  formGroup: FormGroup;
  gitRepos: any[] = [];
  allResult: any[] = []
  showImage: boolean = true;
  allowEdit: boolean = false;
  showFork:boolean = false;

  constructor(private formBuilder: FormBuilder,
    private githubProcessorService: GithubProcessorService) { }

  ngOnInit(): void {

    this.formGroup = this.formBuilder.group({
      showImage: true,
      allowEdit: false,
      showFork: false
    });

    this.githubProcessorService.getAll().subscribe((res: any[]) => {
      if (res != null) {
        this.allResult = res.sort((a, b) => (a.name < b.name ? -1 : 1));
        console.log(res)
        this.gitRepos = this.allResult.filter(x=>x.fork==false);
      }
    });

    this.formGroup.controls['showImage'].valueChanges.subscribe(value => {
      this.showImage = value
    })

    this.formGroup.controls['showFork'].valueChanges.subscribe(value => {
      this.showFork = value
      if(this.showFork){
        this.gitRepos =  this.allResult;
      }else{
        this.gitRepos = this.allResult.filter(x=>x.fork==false);
      }
    })

    this.formGroup.controls['allowEdit'].valueChanges.subscribe(value => {
      this.allowEdit = value
    })
  }
}
