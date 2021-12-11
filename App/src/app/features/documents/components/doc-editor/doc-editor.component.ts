import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { of } from 'rxjs';
import { debounceTime, switchMap } from 'rxjs/operators';
import { ToasterService } from 'src/app/shared/services/toaster.service';
import { QuillConfiguration } from '../../config/quill-configuration';
import { DocumentService } from '../../services/document.service';

@Component({
  selector: 'app-doc-editor',
  templateUrl: './doc-editor.component.html',
  styleUrls: ['./doc-editor.component.scss']
})
export class DocEditorComponent implements OnInit {

  quillConfig = QuillConfiguration;
  docId: string;
  documentForm: FormGroup;
  public formValid: boolean = true;


  constructor(private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private toasterService: ToasterService,
    private documentService: DocumentService) { }

  ngOnInit(): void {
    this.docId = this.route.snapshot.params['id'];

    this.documentForm = this.formBuilder.group({
      content: null
    });

    this.getById(this.docId);

    this.documentForm.valueChanges
      .pipe(
        debounceTime(1500),
        switchMap((value) => of(value))
      )
      .subscribe((value) => {
        this.saveDocument(value);
      });
  }

  get documentRawControl() {
    return this.documentForm.controls.content as FormControl;
  }
  getById(docId: string) {
    this.documentService.getByDocId(docId).subscribe(res => {
      if (res != null) {
        this.documentForm.patchValue({
          content: res.content
        });
      }
    }, (e) => {
      this.toasterService.openSnackBar('Error Occured!', 'Ok');
    })

  }

  saveDocument(value:any){
    this.documentService.save(this.docId,value.content).subscribe();
  }
}
