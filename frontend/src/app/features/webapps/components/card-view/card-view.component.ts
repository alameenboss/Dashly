import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup } from "@angular/forms";
import { Webapp } from "../../models/Webapp.model";
import { WebappService } from "../../services/webapp.service";

@Component({
  selector: "app-card-view",
  templateUrl: "./card-view.component.html",
  styleUrls: ["./card-view.component.scss"],
})
export class CardViewComponent implements OnInit {
  formGroup: FormGroup;
  webapps: Webapp[] = _DATA_;
  showImage: boolean = true;
  allowEdit: boolean = true;

  constructor(
    private formBuilder: FormBuilder,
    private templateService: WebappService
  ) {}

  ngOnInit(): void {
    this.formGroup = this.formBuilder.group({
      showImage: true,
      allowEdit: false,
    });
    this.getAllWebApp();

    this.formGroup.controls["showImage"].valueChanges.subscribe((value) => {
      this.showImage = value;
    });
    this.formGroup.controls["allowEdit"].valueChanges.subscribe((value) => {
      this.allowEdit = value;
    });
  }

  getAllWebApp() {
    this.templateService.getAll().subscribe((res: Webapp[]) => {
      if (res != null) {
        this.webapps = res;
      }
    });
  }

  onFormSubmit() {
    alert(JSON.stringify(this.formGroup.value, null, 2));
  }
}
let _DATA_: Webapp[] = [
  {
    id: 1,
    name: "Google",
    hostedLocationUrl: "https://www.google.com",
  },
  {
    id: 2,
    name: "facebook",
    hostedLocationUrl: "https://www.facebook.com",
  },
  {
    id: 3,
    name: "Microsoft",
    hostedLocationUrl: "https://www.microsoft.com",
  },
];
