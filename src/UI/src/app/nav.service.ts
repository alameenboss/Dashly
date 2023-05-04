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
      { displayName: 'Projects', iconName: 'code', route: '/projects' , children: [
        { displayName: 'List', iconName: 'list', route: '/projects/listview' },
        { displayName: 'Card', iconName: 'view_day', route: '/projects/cardview' }
      ]},
      
      { displayName: 'Notes', iconName: 'text_snippet', route: '/notes' },
      { displayName: 'Documents', iconName: 'description', children: [
        { displayName: 'New', iconName: 'add', route: '/documents' },
        { displayName: 'List', iconName: 'list', route: '/documents/list' }
      ]},
      { displayName: 'Integration', iconName: 'integration_instructions', children: [
        { displayName: 'Add', iconName: 'add', route: '/integration/add' },
        { displayName: 'List', iconName: 'list', route: '/integration/list' }
      ]}, 
      { displayName: 'Task', iconName: 'task', route: '/task' },
      { displayName: 'Contacts', iconName: 'contact_page', route: '/contacts', children: [
        { displayName: 'Edit', iconName: 'add', route: '/contacts' },
        { displayName: 'List', iconName: 'list', route: '/contacts/list' }
      ]},
      { displayName: 'Show Events', iconName: 'contact_page', route: '/showevents'},
      { displayName: 'Video', iconName: 'video_library', route: '/video-player' },
    ]
  }
}