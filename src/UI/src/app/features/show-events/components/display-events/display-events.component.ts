import {
  Component,
  ChangeDetectionStrategy,
  ViewChild,
  TemplateRef
} from '@angular/core';
import {
  startOfDay,
  endOfDay,
  isSameDay,
  isSameMonth,
} from 'date-fns';
import { Subject } from 'rxjs';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import {
  CalendarEvent,
  CalendarEventAction,
  CalendarEventTimesChangedEvent,
  CalendarView,
} from 'angular-calendar';
import { NgxCsvParser, NgxCSVParserError } from 'ngx-csv-parser';
import { EventsService } from '../../services/events.service';
import { ToasterService } from 'src/app/shared/services/toaster.service';
import { PhoneCallsService } from '../../services/phone-calls.service';
@Component({
  selector: 'app-display-events',
  templateUrl: './display-events.component.html',
  styleUrls: ['./display-events.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class DisplayEventsComponent {
  csvRecords: any;
  header: boolean = true;


  @ViewChild('modalContent', { static: true }) modalContent: TemplateRef<any>;

  view: CalendarView = CalendarView.Month;

  CalendarView = CalendarView;

  viewDate: Date = new Date();

  modalData: {
    action: string;
    event: CalendarEvent;
  };

  actions: CalendarEventAction[] = [
    {
      label: '<i class="fas fa-fw fa-pencil-alt"></i>',
      a11yLabel: 'Edit',
      onClick: ({ event }: { event: CalendarEvent }): void => {
        this.handleEvent('Edited', event);
      },
    },
    {
      label: '<i class="fas fa-fw fa-trash-alt"></i>',
      a11yLabel: 'Delete',
      onClick: ({ event }: { event: CalendarEvent }): void => {
        this.allEvents = this.allEvents.filter((iEvent) => iEvent !== event);
        this.handleEvent('Deleted', event);
      },
    },
  ];

  refresh = new Subject<void>();

  allEvents: CalendarEvent[] = [];
  events: CalendarEvent[] = [];
  contacts = [];
  filtredEvents = [];
  activeDayIsOpen: boolean = false;

  constructor(
    private ngxCsvParser: NgxCsvParser,
    private modal: NgbModal,
    private phoneCallsService: PhoneCallsService,
    private toasterService: ToasterService,
    private eventsService: EventsService) {
    let _events = [];
    // let _events = this.eventsService.getEvents();
    let calls = this.eventsService.callList.split(",");
    calls.forEach(call => {
      let trimmedCall = call.trim().replace("Call@", "").replace(".mp3", "")
      let name = trimmedCall.split("(")[0]
      let number = trimmedCall.split("(")[1].split(")")[0].replace('0091', "")
      let callDate = trimmedCall.split(")")[1].replace("_", "");

      let ___date = new Date(
        parseInt(callDate.substr(0, 4)),
        parseInt(callDate.substr(4, 2)) - 1,
        parseInt(callDate.substr(6, 2)),
        parseInt(callDate.substr(8, 2)),
        parseInt(callDate.substr(10, 2)),
        parseInt(callDate.substr(12, 2))
      );

      _events.push(
        {
          start: ___date,
          title: name + '-' + number,
          type: "recording",
          color: {
            primary: this.stringToColour(name + '-' + number).b,
            secondary: this.stringToColour(name + '-' + number).b,
            secondaryText: '#000000'
          }
        })
    })

    this.init(_events);
  }

  @ViewChild('fileImportInput') fileImportInput: any;

  init(_events) {


    this.allEvents = _events;
    this.events = this.allEvents;
    this.initContacts();
  }
  fileChangeListener($event: any): void {

    const files = $event.srcElement.files;
    this.header = (this.header as unknown as string) === 'true' || this.header === true;

    this.ngxCsvParser.parse(files[0], { header: this.header, delimiter: ',', encoding: 'utf8' })
      .pipe().subscribe({
        next: (result): void => {
          // console.log('Result', result);
          this.csvRecords = result;
          this.parseCsv();
        },
        error: (error: NgxCSVParserError): void => {
          //console.log('Error', error);
        }
      });


  }

  parseCsv() {
    let _events = [];
    // let _events = this.eventsService.getEvents();
    let calls = this.eventsService.callList.split(",");
    calls.forEach(call => {
      let trimmedCall = call.trim().replace("Call@", "").replace(".mp3", "")
      let name = trimmedCall.split("(")[0]
      let number = trimmedCall.split("(")[1].split(")")[0].replace('0091', "")
      let callDate = trimmedCall.split(")")[1].replace("_", "");
      let ___date = new Date(
        parseInt(callDate.substr(0, 4)),
        parseInt(callDate.substr(4, 2)) - 1,
        parseInt(callDate.substr(6, 2)),
        parseInt(callDate.substr(8, 2)),
        parseInt(callDate.substr(10, 2)),
        parseInt(callDate.substr(12, 2))
      );

      _events.push(
        {
          start: ___date,
          title: name + '-' + number,
          type: "recording",
          color: {
            primary: this.stringToColour(name + '-' + number).b,
            secondary: this.stringToColour(name + '-' + number).b,
            secondaryText: '#000000'
          }
        })
    })
    this.csvRecords.forEach(call => {
      const [day, month, year, hour, minute, second, ampm] = call.Date.split(/\/|:|\s/);
      let __date = new Date(parseInt(`20${year}`), month - 1, day, hour % 12 + (ampm === 'PM' ? 12 : 0), minute, second);


      _events.push(
        {
          start: __date,
          title: call.Name + '-' + call.Phone.replace("+91", "").replace("-", ""),
          type: "call log"
        })
    })

    this.init(_events);
  }

  selectAllContact() {
    this.contacts.forEach(x => x.checked = true)
    this.filterContact();
  }

  removeAllContact() {
    this.contacts.forEach(x => x.checked = false);
    this.filterContact();
  }

  resetContact() {

  }

  stringToColour(str) {
    let hash = 0;
    for (let i = 0; i < str.length; i++) {
      hash = str.charCodeAt(i) + ((hash << 5) - hash);
    }
    let colour = '#';
    let rgb = []
    for (let i = 0; i < 3; i++) {
      let value = (hash >> (i * 8)) & 0xFF;
      let colorRGB = ('00' + value.toString(16)).substr(-2);
      colour += colorRGB;
      rgb.push(colorRGB)
    }
    const brightness = (parseInt(rgb[0], 16) * 299
      + parseInt(rgb[1], 16) * 587
      + parseInt(rgb[2], 16) * 114)
      / 1000
    const textColor = brightness > 125 ? '#0a0a0a' : '#f2f2f2';

    let x = { b: colour, t: textColor };
    return x
  }

  initContacts() {
    let numberList = [
      '8438523499', '9443205059', '9150323836', '9442950560', '9003967612',
      '9789453471', '9880372543', '8870978627', '9342729963', '8925753686',
      '7868811987', '6374981995', '9443567127', '7845065093', '8610136615',
      '9940836716', '9994038636', '9443104205', '9597673692', '7502080994']

    let _contacts = [];

    this.allEvents.forEach(x => {
      // x.color = {
      //   primary: this.stringToColour('x.type'),
      //   secondary:  '#FDF1BA',
      // }

      if (!_contacts.find(y => y.number === x.title.split('-')[1])) {
        _contacts.push({
          name: x.title.split('-')[0],
          number: x.title.split('-')[1],
          count: 1,
          checked: numberList.find(y => y === x.title.split('-')[1])
        })
      } else {
        let contact = _contacts.find(y => y.number === x.title.split('-')[1])
        contact.count += 1;
      }

    })

    this.contacts = _contacts;
    this.sortContacts();
  }

  sortContacts() {
    this.contacts = this.contacts
      .sort((a, b) => (a.checked) ? 1 : (b.checked) ? -1 : 0).reverse()
      //.sort((a, b) => (a.name > b.name) ? 1 : ((b.name > a.name) ? -1 : 0))
      // .reverse()
      ;
  }

  filterContact(): void {
    let filteredContact = this.contacts.filter(item => item.checked).map((x) => x.number);
    this.events = this.allEvents.filter(item => filteredContact.includes(item.title.split('-')[1]));
    this.sortContacts();
    this.filterDate();

  }

  flatpickrChanged(selectedDates) {
    this.setView(CalendarView.Day)
    this.viewDate = selectedDates[0];
  }

  flatpickrMonthChanged(instance) {
    this.setView(CalendarView.Month)
    this.viewDate = new Date(instance.currentYear, instance.currentMonth, 1);
  }

  dayClicked({ date, events }: { date: Date; events: CalendarEvent[] }): void {
    if (isSameMonth(date, this.viewDate)) {
      if (
        (isSameDay(this.viewDate, date) && this.activeDayIsOpen === true) ||
        events.length === 0
      ) {
        this.activeDayIsOpen = false;
      } else {
        this.activeDayIsOpen = true;
      }
      this.viewDate = date;
    }
  }

  eventTimesChanged({
    event,
    newStart,
    newEnd,
  }: CalendarEventTimesChangedEvent): void {
    this.allEvents = this.allEvents.map((iEvent) => {
      if (iEvent === event) {
        return {
          ...event,
          start: newStart,
          end: newEnd,
        };
      }
      return iEvent;
    });
    this.handleEvent('Dropped or resized', event);
  }

  handleEvent(action: string, event: CalendarEvent): void {
    this.modalData = { event, action };
    // this.modal.open(this.modalContent, { size: 'lg' });
  }

  addEvent(): void {
    this.allEvents = [
      ...this.allEvents,
      {
        title: 'New event',
        start: startOfDay(new Date()),
        end: endOfDay(new Date()),
        color: {
          primary: '#e3bc08',
          secondary: '#FDF1BA',
        },
        draggable: true,
        resizable: {
          beforeStart: true,
          afterEnd: true,
        },
      },
    ];
  }

  deleteEvent(eventToDelete: CalendarEvent) {
    this.allEvents = this.allEvents.filter((event) => event !== eventToDelete);
  }

  setView(view: CalendarView) {
    this.view = view;
    this.filterDate();
  }

  filterDate() {
    let _filtredEvents = this.events.filter(x => x.start.getMonth() == this.viewDate.getMonth()
      && x.start.getFullYear() == this.viewDate.getFullYear())

    let xxxx = [];
    _filtredEvents.forEach(x => {
      if (!xxxx.find(y => y.number === x.title.split('-')[1])) {
        xxxx.push({
          name: x.title.split('-')[0],
          number: x.title.split('-')[1],
          count: 1,
          date: [x.start]
        })
      } else {
        let contact = xxxx.find(y => y.number === x.title.split('-')[1])
        contact.count += 1;
        contact.date.push(x.start)
      }
    })
    this.filtredEvents = xxxx;
  }

  closeOpenMonthViewDay() {
    this.activeDayIsOpen = false;
    this.filterDate();
  }

  scanFolder() {
    this.phoneCallsService.scan().subscribe(x => {
      this.toasterService.openSnackBar("Scanning the folder in background.", null)
    }, (err) => { console.log(err) })
  }
}
