import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { IntegrationService } from '../../services/integration.service';

@Component({
  selector: 'app-signin',
  templateUrl: './signin.component.html',
  styleUrls: ['./signin.component.scss']
})
export class SignInComponent implements OnInit {

  showLink: boolean = false;
  showMessage: boolean = false;
  clientId: string;

  constructor(private route: ActivatedRoute,
    private router:Router,
    private integrationService: IntegrationService) { }

  ngOnInit(): void {
    let code = this.route.snapshot.queryParams['code'];
    let appName = this.route.snapshot.queryParams['appname'];
    if (appName == null || appName == undefined) {
this.router.navigateByUrl("/")
    } else {
      if (code == null || code == undefined) {
        this.integrationService.getOAuthClientIdByName(appName).subscribe((res: any) => {
          if (res != null) {
            this.clientId = res.clientId;
            this.showLink = true
          }
        })
      } else {
        this.integrationService.updateOAuthCode(appName, code).subscribe(res => {
          console.log('updateOAuthCode', res)
        })
      }
    }

  }

}
