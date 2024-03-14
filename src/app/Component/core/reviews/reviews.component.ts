import { Component, HostListener } from '@angular/core';
import { Review } from 'src/app/models/review';
@Component({
  selector: 'app-reviews',
  templateUrl: './reviews.component.html',
  styleUrls: ['./reviews.component.css'],
})
export class ReviewsComponent {
  counter = 0;
  lenSlider = 1;

  reviews: Review[] = [];

  constructor() {
    this.reviews = [
      {
        rate: 5,
        content: ` أنا موظف وشغال في فترة الصبح لكن كنت بدور على حاجة تزود دخلي لحد ما
        وصلت لتاجر، أول شهر عملت 50 أوردر ودلوقتي وصلت ل20 ألف أوردر`,
        name: 'محمد',
        region: 'مصر',
      },
      {
        rate: 4,
        content: ` أنا موظف وشغال في فترة الصبح لكن كنت بدور على حاجة تزود دخلي لحد ما
        وصلت لتاجر، أول شهر عملت 50 أوردر ودلوقتي وصلت ل20 ألف أوردر`,
        name: 'محمود',
        region: 'مصر',
      },
      {
        rate: 3,
        content: ` أنا موظف وشغال في فترة الصبح لكن كنت بدور على حاجة تزود دخلي لحد ما
        وصلت لتاجر، أول شهر عملت 50 أوردر ودلوقتي وصلت ل20 ألف أوردر`,
        name: 'مالك',
        region: 'مصر',
      },
      {
        rate: 2,
        content: ` أنا موظف وشغال في فترة الصبح لكن كنت بدور على حاجة تزود دخلي لحد ما
        وصلت لتاجر، أول شهر عملت 50 أوردر ودلوقتي وصلت ل20 ألف أوردر`,
        name: 'مصطفى',
        region: 'مصر',
      },
      {
        rate: 2,
        content: ` أنا موظف وشغال في فترة الصبح لكن كنت بدور على حاجة تزود دخلي لحد ما
        وصلت لتاجر، أول شهر عملت 50 أوردر ودلوقتي وصلت ل20 ألف أوردر`,
        name: 'توتا',
        region: 'مصر',
      },
      {
        rate: 2,
        content: ` أنا موظف وشغال في فترة الصبح لكن كنت بدور على حاجة تزود دخلي لحد ما
        وصلت لتاجر، أول شهر عملت 50 أوردر ودلوقتي وصلت ل20 ألف أوردر`,
        name: 'احمد',
        region: 'مصر',
      },
      {
        rate: 2,
        content: ` أنا موظف وشغال في فترة الصبح لكن كنت بدور على حاجة تزود دخلي لحد ما
        وصلت لتاجر، أول شهر عملت 50 أوردر ودلوقتي وصلت ل20 ألف أوردر`,
        name: 'سما',
        region: 'مصر',
      },
    ];
  }

  get SlidersCount() {
    return this.reviews.length / this.lenSlider;
  }

  range = (start: number, end: number) =>
    Array.from({ length: end - start }, (_, k) => k + start);

  fillSlider(counter: number) {
    var reviewsSlider = [];
    var start = counter * this.lenSlider;
    for (let i = start; i < start + this.lenSlider; i++) {
      reviewsSlider.push(this.reviews[i % this.reviews.length]);
    }
    return reviewsSlider;
  }

  iterateSlider() {
    return this.fillSlider(this.counter++);
  }

  isFirst(i: number): boolean {
    return i == 0;
  }
  private changeSliderLen = () =>
    (this.lenSlider = window.innerWidth < 576 ? 1 : 3);

  @HostListener('window:resize', ['$event'])
  onResize = (event: Event) => this.changeSliderLen();

  @HostListener('window:load', ['$event'])
  onLoade = (event: Event) => this.changeSliderLen();
}
