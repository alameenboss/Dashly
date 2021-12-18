import { Component, OnInit } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Observable } from 'rxjs';
import { map, shareReplay } from 'rxjs/operators';
import { Router } from '@angular/router';
import { User } from 'src/app/features/authentication/models/user';
import { AuthenticationService } from 'src/app/features/authentication/services/authentication.service';
import { Role } from 'src/app/features/authentication/models/role';
import { NavService } from 'src/app/nav.service';


@Component({
  selector: 'app-main-nav',
  templateUrl: './main-nav.component.html',
  styleUrls: ['./main-nav.component.scss']
})
export class MainNavComponent implements OnInit {

  // isHandset$: Observable<boolean> = this.breakpointObserver.observe(Breakpoints.Handset)
  //   .pipe(
  //     map(result => result.matches),
  //     shareReplay()
  //   );

  // constructor(private breakpointObserver: BreakpointObserver) {}
  currentUser: User;
  menuList: any[];
  items:any[]=['Projects', 'Angular Jira Clone', 'Kanban Board'];
  constructor(
    private router: Router,
    private navService : NavService,
    private authenticationService: AuthenticationService
  ) {
    this.authenticationService.currentUser.subscribe(x => this.currentUser = x);

  }
  ngOnInit(): void {
    this.router.events.subscribe(_=>{
      console.log("Route Event",_)
    })
    this.menuList = this.navService.getMenu();
  }

  get isAdmin() {
    return this.currentUser && this.currentUser.role?.name === 'Admin';
  }

  logout() {
    this.authenticationService.logout();
    this.router.navigate(['authentication', 'login']);
  }

  gotoHome() {
    this.router.navigate(['/']);
  }


}
