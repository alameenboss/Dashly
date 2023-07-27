import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToasterService } from 'src/app/shared/services/toaster.service';
import { WebappService } from '../../services/webapp.service';
import { Location } from '@angular/common'

@Component({
  selector: 'app-add-edit-webapp',
  templateUrl: './add-edit-webapp.component.html',
  styleUrls: ['./add-edit-webapp.component.scss']
})
export class AddEditWebappComponent implements OnInit {
  webappForm: FormGroup;
  public formValid: boolean = true;
  private webappId: number = 0;
  private webapp: any;

  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private location: Location,
    private router: Router,
    private toasterService: ToasterService,
    private webappService: WebappService
  ) {

  }

  ngOnInit() {
    this.webappId = this.route.snapshot.params['id'];

    this.webappForm = this.formBuilder.group({
      name: [null, Validators.required],
      description: null,
      hostedLocationUrl: [null],
      packagedZipFileUrl: null,
      demoUrl: null,
      projectsUrl: null,
      attachments: this.formBuilder.array([]),
      tags: this.formBuilder.array([]),
      type: null,
      authorName: null,
      isLocal: true,
      isActive: true
    });

    if (this.webappId > 0) {
      this.getById(this.webappId);
    }
  }

  // convenience getter for easy access to form fields
  get f() { return this.webappForm.controls; }

  getById(id: number) {
    this.webappService.getById(id).subscribe(res => {
      this.webapp = null;
      if (res != null) {
        this.webapp = res;
        this.patchForm(this.webapp);
      }
    }, (e) => {
      this.toasterService.openSnackBar('Error Occured!', 'Ok');
    })

  }

  onSubmit() {
    this.formValid = false;
    if (this.webappForm.invalid) {
      return;
    } else {
      let request = this.webappForm.value;
      if (this.webappId > 0) {
        request.id = +this.webappId;
        this.webappService.update(request.id, request).subscribe(res => {
          this.toasterService.openSnackBar('Updated successfully!', 'Ok');
          this.location.back()
        });
      } else {
        this.webappService.insert(request).subscribe(res => {
          this.toasterService.openSnackBar('Added successfully!', 'Ok');
          this.router.navigateByUrl(`webapp`);
        });
      }
    }
  }

  //#region "Attachment"
  addAttachment() {
    let attachmentsArray = <FormArray>this.webappForm.controls['attachments'];
    attachmentsArray.push(this.getAttachmentsFormGroup());
  }
  removeAttachment(index) {
    let attachmentsArray = <FormArray>this.webappForm.controls['attachments'];
    attachmentsArray.removeAt(index)
  }

  getAttachmentsFormGroup(_name:string=null) {
    return this.formBuilder.group({
      name: _name,
      type: null,
      isPrimary: false
    })
  }

  get attachments(): FormArray {
    return this.webappForm.get('attachments') as FormArray;
  };
  //#endregion 

  //#region "Tags"
  addTag() {
    let tagsArray = <FormArray>this.webappForm.controls['tags'];
    tagsArray.push(this.getTagsFormGroup());
  }
  removeTag(index) {
    let tagsArray = <FormArray>this.webappForm.controls['tags'];
    tagsArray.removeAt(index)
  }

  getTagsFormGroup() {
    return this.formBuilder.group({
      name: null,
      type: null,
      isPrimary: false
    })
  }

  get tags(): FormArray {
    return this.webappForm.get('tags') as FormArray;
  };

  //#endregion

  //#region "Patch Value"
  patchForm(input: any) {
    this.webappForm.patchValue({
      name: input.name,
      description: input.description,
      hostedLocationUrl: input.hostedLocationUrl,
      packagedZipFileUrl: input.packagedZipFileUrl,
      demoUrl: input.demoUrl,
      projectsUrl: input.projectsUrl,
      type: input.type,
      authorName: input.authorName,
      isActive: input.isActive,
      isLocal: input.isLocal
    });

    this.setAttachments(input.attachments)
    this.setTags(input.tags)
  }

  setAttachments(attachments: []) {
    const attachmentsFGs = attachments.map(a => this.formBuilder.group(a));
    const attachmentsFormArray = this.formBuilder.array(attachmentsFGs);
    this.webappForm.setControl('attachments', attachmentsFormArray);
  }

  setTags(tags: []) {
    const tagsFGs = tags.map(a => this.formBuilder.group(a));
    const tagsFormArray = this.formBuilder.array(tagsFGs);
    this.webappForm.setControl('tags', tagsFormArray);
  }
  //#endregion

  public uploadFinished = (event) => {
    let attachmentsArray = <FormArray>this.webappForm.controls['attachments'];
    attachmentsArray.push(this.getAttachmentsFormGroup(event));
  }
}
