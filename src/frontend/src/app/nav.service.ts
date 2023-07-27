import {Injectable} from '@angular/core';
import {Event, NavigationEnd, Router} from '@angular/router';
import {BehaviorSubject} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
@Injectable()
export class NavService {
  public appDrawer: any;
  public currentUrl = new BehaviorSubject<string>(undefined);

  constructor(private router: Router) {
    this.router.events.subscribe((event: Event) => {
      if (event instanceof NavigationEnd) {
        this.currentUrl.next(event.urlAfterRedirects);
      }
    });
  }

  public closeNav() {
    this.appDrawer.close();
  }

  public openNav() {
    this.appDrawer.open();
  }
  public getMenu() {
    return [
      { displayName: 'Dashboard', iconName: 'dashboard', route: "/dashboard" },
      {
        displayName: 'Webapps', iconName: 'public', route: 'webapp/cardview'
      },
      { displayName: 'Import Data', iconName: 'upload_file', route: '/dashboard/import' },
      { displayName: 'File Explorer', iconName: 'folder_open', route: '/fileexplorer' },    
      { displayName: 'Notes', iconName: 'text_snippet', route: '/notes' }
    ]
  }
}