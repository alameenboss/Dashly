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
      { displayName: 'Dashboard', iconName: 'group', route: "/dashboard" },
      {
        displayName: 'Webapps', iconName: 'group', route: 'webapp', children: [
          { displayName: 'Add', iconName: 'group', route: '/webapp/add' },
          { displayName: 'List View', iconName: 'group', route: '/webapp/listview' },
          { displayName: 'Cards View', iconName: 'group', route: '/webapp/cardview' }
        ]
      },
      { displayName: 'Import Data', iconName: 'group', route: '/dashboard/import' },
      { displayName: 'File Explorer', iconName: 'group', route: '/fileexplorer' },
      { displayName: 'Git Hub Repo', iconName: 'group', route: '/github' , children: [
        { displayName: 'List View', iconName: 'group', route: '/github/listview' },
        { displayName: 'Cards View', iconName: 'group', route: '/github/cardview' }
      ]},
      
      { displayName: 'Notes', iconName: 'group', route: '/notes' },
      { displayName: 'Documents', iconName: 'group', children: [
        { displayName: 'New', iconName: 'group', route: '/documents' },
        { displayName: 'List', iconName: 'group', route: '/documents/list' }
      ]},
      { displayName: 'Integration', iconName: 'group', children: [
        { displayName: 'Add', iconName: 'group', route: '/integration/add' },
        { displayName: 'List', iconName: 'group', route: '/integration/list' }
      ]}, 
      { displayName: 'Contacts', iconName: 'group', route: '/contacts' },
      { displayName: 'Family Hierarchy', iconName: 'group', route: '/family' },
      { displayName: 'Passwords', iconName: 'group', route: '/password' },
      { displayName: 'Pay Slips', iconName: 'group', route: '/payslips' },
      { displayName: 'Video', iconName: 'group', route: '/video' },
      { displayName: 'Audio', iconName: 'group', route: '/audio' },
      { displayName: 'Bookmarks', iconName: 'group', route: '/bookmarks' },
      { displayName: 'feedback', iconName: 'group', route: '/feedback' }
    ]
  }
}